import {useContext} from "react";
import { VillageContext} from "../contexts/VillageContext.jsx";

export default function useVillage(){
    const { village } = useContext(VillageContext) ;
    return village;
}

