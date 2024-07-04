import {useContext} from "react";
import { VillagesContext} from "../contexts/VillagesContext.jsx";

export default function useVillages(){
    const { villages } = useContext(VillagesContext) ;
    return villages;
}

