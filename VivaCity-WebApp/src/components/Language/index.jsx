import { useLanguageContext } from "../../contexts/languageContext.jsx";
import {MenuItem, MenuItems} from "@headlessui/react";
import React from "react";

function classNames(...classes) {
    return classes.filter(Boolean).join(' ')
}
const LanguageSelect = () => {
    const { languages, onClickLanguageChange } = useLanguageContext();
    return (
        <div>
            {Object.keys(languages).map((lng) => (
                <MenuItem  key={languages[lng].nativeName}
                           value={lng}
                           onClick={() => onClickLanguageChange(lng)}>
                    {({ focus }) => (
                        <div
                            className={classNames(focus ? 'bg-gray-100' : '', 'block px-4 py-2 text-sm text-gray-700')}
                        >
                            {languages[lng].nativeName}
                        </div>
                    )}
                </MenuItem>


            ))}
        </div>
    );
};

export default LanguageSelect;
