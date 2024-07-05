import {useLanguageContext} from "../../contexts/languageContext.jsx";
import React, { useEffect, useState } from 'react';
import useRanking from "../../business/ranking.js";
import getRanking from "../../business/ranking.js";

export default function Rank() {
	const [rankings, setRankings] = useState([]);
	const [loading, setLoading] = useState(true);
	const [error, setError] = useState(null);
	const { t } = useLanguageContext();

	useEffect(() => {
		async function fetchRankings() {
			try {
				const r = await getRanking();
				setRankings(r);
				setLoading(false);
			} catch (e) {
				setError('Failed to fetch ranking');
				setLoading(false);
			}
		}

		fetchRankings();
	}, []);

	if (loading) {
		return <p>Loading...</p>;
	}

	if (error) {
		return <p>{error}</p>;
	}

	return (
		<>
			<ul role="list" className="divide-y divide-gray-100" style={{padding:'50px',background:'black'}} >
				{rankings.map((ranking, index) => (
					<li key={index} className="flex justify-between gap-x-6 py-5"  >
						<div className="flex min-w-0 gap-x-4">
							<div className="min-w-0 flex-auto">
								<p style={{color:'white',fontWeight:'bold'}} className="text-sm font-semibold leading-6 text-gray-900" >{ranking.pseudo}</p>
							</div>
						</div>
						<div className="hidden shrink-0 sm:flex sm:flex-col sm:items-end">
							<p style={{color:'white',fontWeight:'bold'}} className="text-sm leading-6 text-gray-900">{ranking.score}</p>
						</div>
					</li>
				))}
			</ul>
		</>
	);
}







