import {useContext} from "react";
import { VillageContext} from "../contexts/VillageContext.jsx";

export default function useVillageSetter(){
    const { setVillage } = useContext(VillageContext) ;
    return setVillage;
}

