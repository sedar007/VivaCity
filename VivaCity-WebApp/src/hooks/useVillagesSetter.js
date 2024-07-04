import {useContext} from "react";
import { VillagesContext} from "../contexts/VillagesContext.jsx";

export default function useVillagesSetter(){
    const { setVillages } = useContext(VillagesContext) ;
    return setVillages;
}

