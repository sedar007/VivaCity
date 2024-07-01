import React from 'react';
import ReactDOM from 'react-dom/client';
import Router from './components/Router';

import './index.css';

import './i18next.jsx'
import {LanguageContextProvider} from "./contexts/languageContext.jsx";
import Language from "./components/Language/index.jsx";

ReactDOM.createRoot(document.getElementById('root')).render(
      <LanguageContextProvider>
        <Router />
      </LanguageContextProvider>
)
