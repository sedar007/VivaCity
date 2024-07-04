import React from 'react';
import ReactDOM from 'react-dom/client';
import Router from './components/Router';

import './index.css';

import './i18next.jsx'
import {LanguageContextProvider} from "./contexts/languageContext.jsx";
import {VillageContextProvider} from "./contexts/VillageContext.jsx";


ReactDOM.createRoot(document.getElementById('root')).render(
    <VillageContextProvider>
      <LanguageContextProvider>
              <Router />
      </LanguageContextProvider>
    </VillageContextProvider>
)

