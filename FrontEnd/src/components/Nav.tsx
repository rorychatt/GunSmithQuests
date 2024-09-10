import {PageTitle} from "./PageTitle.tsx";
import {Options} from "./Options.tsx";

export function Nav(){
    return (
        <nav className="flex justify-center items-center mt-4">
            <ul className="flex space-x-4">
                <li>
                    <PageTitle></PageTitle>
                </li>
                <li>
                    <Options></Options>
                </li>
            </ul>
        </nav>
    )
}