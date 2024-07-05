import {useLanguageContext} from "../../contexts/languageContext.jsx";
import useRanking from "../../business/ranking.js";
import getRanking from "../../business/ranking.js";






	async function rnk() {
		const r = await getRanking();
		return r;

	}

const rankings = rnk();
console.log(rankings);



export default function Rank() {
	const { t } = useLanguageContext();
	return (
		<>
		{/*	<ul role="list" className="divide-y divide-gray-100">
				{rankings.map((ranking) => (
					<li key={ranking.pseudo} className="flex justify-between gap-x-6 py-5">
						<div className="flex min-w-0 gap-x-4">
							<div className="min-w-0 flex-auto">
								<p className="text-sm font-semibold leading-6 text-gray-900">{ranking.pseudo}</p>
							</div>
						</div>
						<div className="hidden shrink-0 sm:flex sm:flex-col sm:items-end">
							<p className="text-sm leading-6 text-gray-900">{ranking.score}</p>

						</div>
					</li>
				))}
			</ul>*/}
		</>
	);
}







