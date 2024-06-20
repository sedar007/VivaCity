import { useEffect, useState } from 'react';
import {useLanguageContext} from "../../contexts/languageContext.jsx";

export default function Home() {
	const { t } = useLanguageContext();
	return (
		<>
			<h1 className="text-3xl font-bold underline">
				Hello world!
				<div>{t("English")}</div>
				<div>{t("French")}</div>
			</h1>
		</>
	);
}