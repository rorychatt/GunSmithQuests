import './App.css'
import '@fortawesome/fontawesome-free/css/all.min.css'

import {Nav} from "./components/Nav.tsx";
import {Main} from "./components/Main.tsx";

function App() {

    return (
        <div className="flex flex-col items-center justify-center mih-h-screen gap-4">
            <Nav></Nav>
            <Main></Main>
        </div>
    )
}


export default App
