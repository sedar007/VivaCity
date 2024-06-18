import { createContext} from 'react';

export const CounterContext = createContext();

export function CounterContextProvider({ children }) {
	
	return (
		<CounterContext.Provider >
			{children}
		</CounterContext.Provider>
	)
}