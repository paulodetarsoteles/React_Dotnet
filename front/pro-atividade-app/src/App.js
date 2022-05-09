import React, { useEffect } from "react";
import { useState } from "react";
import { Button, Modal } from "react-bootstrap"; 
import "./App.css";
import AtividadeForm from "./components/AtividadeForm";
import AtividadeLista from "./components/AtividadeLista";
import api from './api/atividade'; 

function App() {
  const [showAtividadeModal, setShowAtividadeModal] = useState(false);
  const [smShowConfirmModal, setSmShowConfirmModal] = useState(false);
  const [atividades, setAtividades] = useState([]);
  const [atividade, setAtividade] = useState({id: 0});
  
  const handleAtividadeModal = () => setShowAtividadeModal(!showAtividadeModal);

  const handleConfirmModal = (id) => {
    if(id !== 0 & id !== undefined){
      const atividade = atividades.filter((atividade) => atividade.id === id); 
      setAtividade(atividade[0]);
    }
    else {
      setAtividade({id:0}); 
    }
    setSmShowConfirmModal(!smShowConfirmModal); 
  }

  const pegaTodasAtividades = async () => {
    const response = await api.get('atividade');
    return response.data; 
  }

  useEffect(() => { 
    const getAtividades = async () => {
      const todasAtividades = await pegaTodasAtividades(); 
      if(todasAtividades) setAtividades(todasAtividades); 
    };
    getAtividades(); 
  }, []
  )

  const addAtividade = async (ativ) => {
    const response = await api.post('atividade', ativ); 
    setAtividades([...atividades, response.data]); 
    handleAtividadeModal(); 
  }

  function pegarAtividade(id){
    const atividade = atividades.filter((atividade) => atividade.id === id); 
    setAtividade(atividade[0]);
    handleAtividadeModal(); 
  }

  const atualizarAtividade = async (ativ) => {
    const response = await api.put(`atividade/${ativ.id}`, ativ); 
    const {id} = response.data; 
    setAtividades(atividades.map(item => item.id === id ? response.data : item)); 
    setAtividade({id: 0}); 
    handleAtividadeModal(); 
  }

  function cancelarAtividade(){
    setAtividade({id: 0}); 
    handleAtividadeModal(); 
  }
  
  const deletarAtividade = async (id) => {
    if(await api.delete(`atividade/${id}`)){
      const atividadesFiltradas = atividades.filter((atividade) => atividade.id !== id); 
      setAtividades([...atividadesFiltradas]); 
    }
    handleConfirmModal(0); 
  }

  return (
    <>
      <div className="d-flex justify-content-between align-items-end mt-2 pb-3 border-bottom border-1">
        <h3 className="m-0 p-0">Atividade {atividade.id !== 0 ? atividade.id : ''}</h3>
        <Button variant="primary" onClick={handleAtividadeModal}>
          <i className="fas fa-plus"></i>
        </Button>
      </div>
      <AtividadeLista
        atividades={atividades}
        pegarAtividade={pegarAtividade}
        handleConfirmModal={handleConfirmModal}
      />

      <Modal show={showAtividadeModal} onHide={handleAtividadeModal}>
        <Modal.Header closeButton>
          <Modal.Title>
            <h3 className="m-0 p-0">Atividade {atividade.id !== 0 ? atividade.id : 'Nova'}</h3>
          </Modal.Title>
        </Modal.Header>
        <Modal.Body>      
          <AtividadeForm
            atividades={atividades}
            atividadeSelecionada={atividade}
            addAtividade={addAtividade}
            atualizarAtividade={atualizarAtividade}
            cancelarAtividade={cancelarAtividade}
          />
        </Modal.Body>
      </Modal>

      <Modal size ="sm" show={smShowConfirmModal} onHide={handleConfirmModal}>
        <Modal.Header closeButton>
          <Modal.Title>
            <h3 className="m-0 p-0">
              Excluir Atividade
            </h3>
          </Modal.Title>
        </Modal.Header>
        <Modal.Body>      
          Confirmar a exclusão da atividade {atividade.id}?
        </Modal.Body>
        <Modal.Footer>
          <button className="btn btn-danger me-2" onClick={() => deletarAtividade(atividade.id)}>
            <i className="fas fa-exclamation me-2"></i>
            Excluir
          </button>
          <button className="btn btn-outline-light me-2" onClick={() => handleConfirmModal(0)}>
            Cancelar
          </button>
        </Modal.Footer>
      </Modal>
    </>
  );
}
export default App;