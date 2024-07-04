import { API_URL } from '../../config';




async function _getVillagesByUser(id){
    try {
        const res = await fetch(`${API_URL}Users/getVillges/${id}`);

        if(!res.ok)
            throw new Error(`Failed to fetch user with status code: ${res.status}`);

        return await res.json();
    } catch (error) {
        console.error(error);
        throw error;
    }
}


export async function getVillagesByUser(id){
    try{
        const villages = _getVillagesByUser(id);
        if(villages === null || villages.length === 0)
            throw new Error('Villages not found');
        return villages;
    }
    catch (error) {
        throw error;
    }
}




