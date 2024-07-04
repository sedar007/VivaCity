import React from 'react';
import ReactDOM from 'react-dom/client';
import Router from './components/Router';

import './index.css';

import './i18next.jsx'
import {LanguageContextProvider} from "./contexts/languageContext.jsx";
import {VillageIdContextProvider} from "./contexts/VillageIdContext.jsx";
import {VillagesContextProvider} from "./contexts/VillagesContext.jsx";
import {UsersContextProvider} from "./contexts/UsersContext.jsx";


ReactDOM.createRoot(document.getElementById('root')).render(
    <UsersContextProvider>
    <VillagesContextProvider>
        <VillageIdContextProvider>
          <LanguageContextProvider>
                  <Router />
          </LanguageContextProvider>
        </VillageIdContextProvider>
    </VillagesContextProvider>
    </UsersContextProvider>
)

