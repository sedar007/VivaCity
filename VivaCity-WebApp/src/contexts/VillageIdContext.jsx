import {createContext, useEffect, useState} from 'react';
export const VillageIdContext = createContext();

export function VillageIdContextProvider({ children }){

   // const [village, setVillage ] = useState(parseInt(localStorage.village || '0'));




    const [villageId, setVillageId ] = useState(parseInt(localStorage.village || '0'));

    useEffect(() => {
        localStorage.setItem('villageId', villageId);
    }, [villageId])

    return (
        <VillageIdContext.Provider value={{villageId, setVillageId}} >
            {children}
        </VillageIdContext.Provider>
    )
}