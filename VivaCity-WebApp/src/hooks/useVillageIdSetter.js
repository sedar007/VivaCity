import {useContext} from "react";
import { VillageIdContext} from "../contexts/VillageIdContext.jsx";

export default function useVillageIdSetter(){
    const { setVillageId } = useContext(VillageIdContext) ;
    return setVillageId;
}

