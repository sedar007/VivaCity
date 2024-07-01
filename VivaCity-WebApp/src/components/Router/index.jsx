// import Layout from '../Layout';

// import {
//     createBrowserRouter,
//     RouterProvider,
//   } from 'react-router-dom';
  
  
//   import Home from '../../pages/Home';
//   import Login from '../../pages/Login';
//   import Games from '../../pages/Games';
// import Rank from "../../pages/Rank/index.jsx";
// import LogOut from "../../pages/LogOut/index.jsx";
  
//   const router = createBrowserRouter([
//       {
//       element: <Layout />,
//           children: [
//               {
//                   path: "/",
//                   element: <Home />,
//               },
//               {
//                   path: "/home",
//                   element: <Home />,
//               },
//               {
//                   path: "/login",
//                   element: <Login />,
//               },
//               {
//                   path: "/games",
//                   element: <Games />,
//               },
//               {
//                   path: "/rank",
//                   element: <Rank />,
//               },
//               {
//                   path: "/outxxx",
//                   element: <LogOut />,
//               }
              
//           ]
//       }
//   ]);
  
//   export default function Router() {
//       return (
//           <RouterProvider router={router} />
//       );
//   }

import Layout from '../Layout';
import { createBrowserRouter, RouterProvider } from 'react-router-dom';

import Home from '../../pages/Home';
import Login from '../../pages/Login';
import Games from '../../pages/Games';
import Rank from "../../pages/Rank/index.jsx";
import LogOut from "../../pages/LogOut/index.jsx";

const router = createBrowserRouter([
    {
        element: <Layout />,
        children: [
            {
                path: "/",
                element: <Home />,
            },
            {
                path: "/home",
                element: <Home />,
            },
            {
                path: "/login",
                element: <Login />,
            },
            {
                path: "/games",
                element: <Games />,
            },
            {
                path: "/rank",
                element: <Rank />,
            },
            {
                path: "/outxxx",
                element: <LogOut />,
            }
        ]
    }
]);

export default function Router() {
    return (
        <RouterProvider router={router} />
    );
}
