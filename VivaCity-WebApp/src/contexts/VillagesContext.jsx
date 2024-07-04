import {createContext, useEffect, useState} from 'react';
export const VillagesContext = createContext();

export function VillagesContextProvider({ children }){

   // const [village, setVillage ] = useState(parseInt(localStorage.village || '0'));



    const [villages, setVillages ] = useState(null);

    useEffect(() => {
       // localStorage.setItem('villageId', villageId);
    }, [villages])

    return (
        <VillagesContext.Provider value={{villages, setVillages}} >
            {children}
        </VillagesContext.Provider>
    )
}