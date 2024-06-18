import React from 'react';
import ReactDOM from 'react-dom/client';
import Router from './components/Router';

import './index.css';
import { CounterContextProvider } from './contexts';

ReactDOM.createRoot(document.getElementById('root')).render(
  <React.StrictMode>
        <Router />
  </React.StrictMode>,
)
