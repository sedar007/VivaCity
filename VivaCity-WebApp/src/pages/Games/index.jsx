import React, {useEffect, useState} from 'react';
import Village from '../../components/Village'
import './index.css'
import {useNavigate} from "react-router-dom";
import useVillageId from "../../hooks/useVillageId.js";
import useVillageIdSetter from "../../hooks/useVillageIdSetter.js";
import { getVillagesByUser} from "../../business/villages.js";
import useVillages from "../../hooks/useVillages.js";
import useVillagesSetter from "../../hooks/useVillagesSetter.js";


export default function Games() {

	const navigate = useNavigate();

	useEffect(() => {
		const token = localStorage.getItem('token');
		if (!token) {
			navigate('/login');
		}
	}, [navigate]);

	let villages = useVillages();
	const setVillages = useVillagesSetter();

	async function getVillages(){
		const villages = await getVillagesByUser(localStorage.getItem('idUser'));
		setVillages(villages);
		return villages
	}
	let [village, setVillage] = useState(null);
	const villageId = useVillageId();
	const setVillageId = useVillageIdSetter();

	useEffect(() => {


		getVillages().then(
			 (vill)=> {
				 if(village === null)
					 setVillage(vill[0]);
			}
		)

	}, []);

	//console.log(villages)



	useEffect(() => {
		 function getData() {
			try {
				if(villages === null){
					getVillages().then(
						(vill)=> {
							for(let v in vill) {
								if (v.id === villageId) {
									setVillage(v);
									break;
								}
							}
						}
					)
				}
				
			}
			catch (error) {
				console.error(error);
			}
		}

		getData();

		return () => {};
        }, [villageId]);



	if(village == null)
		return null;



	return (
		<div className="games-container">
			<div className="vill">
				<Village village = {village} />
			</div>
		</div>
	);
}