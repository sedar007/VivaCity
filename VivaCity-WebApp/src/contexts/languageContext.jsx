import React, { createContext, useContext } from "react";
import { useTranslation } from "react-i18next";

export const LanguageContext = createContext(undefined);

export const LanguageContextProvider = ({ children }) => {
    const languages = {
        en: { nativeName: "English" },
        fr: { nativeName: "French" },
    };
    const { t, i18n } = useTranslation();

    const onClickLanguageChange = (language) => {
        localStorage.setItem('lng', language);
        i18n.changeLanguage(language); // Change the language
    };

    return (
        <LanguageContext.Provider
            value={{ t, i18n, onClickLanguageChange, languages }}
        >
            {children}
        </LanguageContext.Provider>
    );
};

export const useLanguageContext = () => useContext(LanguageContext);
