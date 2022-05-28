import React from 'react';
import ReactDOM from 'react-dom/client';
import App from './App';
import 'bootswatch/dist/darkly/bootstrap.min.css'; 
import './index.css';
import './App.css';

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <div className='container'>
    <App />
  </div>
);