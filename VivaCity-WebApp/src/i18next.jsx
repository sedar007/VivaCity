import i18next from "i18next";
import { initReactI18next } from "react-i18next";

import English from "./Translation/English.json";
import French from "./Translation/French.json";

const resources = {
    en: {
        translation: English,
    },
    fr: {
        translation: French,
    },
}

function getLng() {
    if (localStorage.getItem('lng')) {
        return localStorage.getItem('lng');
    }
    localStorage.setItem('lng', 'en');
    return 'en';
}

i18next.use(initReactI18next)
    .init({
        resources,
        lng:getLng(), //default language
    });

export default i18next;