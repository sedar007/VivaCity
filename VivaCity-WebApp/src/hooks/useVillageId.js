import {useContext} from "react";
import { VillageIdContext} from "../contexts/VillageIdContext.jsx";

export default function useVillageId(){
    const { villageId } = useContext(VillageIdContext) ;
    return villageId;
}

