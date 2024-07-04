import {createContext, useEffect, useState} from 'react';
import {getVillageByUser, getVillagesByUser} from "../business/villages.js";
export const VillageContext = createContext();
// eslint-disable-next-line react/prop-types
export function VillageContextProvider({ children }){

    const getV = async () => {
        try {
            const a = await getVillageByUser(9);
            return a;
        } catch (e) {
            console.error(e);
        }

    }
   // const [village, setVillage ] = useState(parseInt(localStorage.village || '0'));

    const [village, setVillage ] = useState(9);







    useEffect(() => {
      //  localStorage.setItem('village', village);
    }, [village])

    return (
        <VillageContext.Provider value={{village, setVillage}} >
            {children}
        </VillageContext.Provider>
    )
}