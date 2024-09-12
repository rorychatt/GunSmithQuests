import { useEffect, useState } from "react";
import { API_URL } from "../constants.ts";
import FileUpload from "./FileUpload.tsx";
import {GunPart} from "./types.ts";

export function Aside({ onAddPart }: { onAddPart: (part: GunPart) => void }) {
    const [gunParts, setGunParts] = useState<GunPart[]>([]);
    const [usedParts, setUsedParts] = useState<GunPart[]>([]);
    const [searchQuery, setSearchQuery] = useState("");

    useEffect(() => {
        const fetchGunParts = async () => {
            try {
                const response = await fetch(`${API_URL}/GunParts/listAll`);
                const data = await response.json();
                setGunParts(data);
            } catch (error) {
                console.error("Error fetching gun parts:", error);
            }
        };

        fetchGunParts();
    }, []);

    const addPartToBuild = (part: GunPart) => {
        setUsedParts([...usedParts, part]);
        onAddPart(part);
    };

    const removePartFromBuild = (part: GunPart) => {
        setUsedParts(usedParts.filter(p => p.id !== part.id));
    };

    const filteredParts = gunParts.filter(part =>
        part.name.toLowerCase().includes(searchQuery.toLowerCase())
    );

    return (
        <aside className="flex flex-col items-center justify-center text-center border-2 border-gray-300 rounded-lg p-4">
            <h2>Used Gun Parts</h2>
            {usedParts.length > 0 ? (
                <ul>
                    {usedParts.map((part) => (
                        <li key={part.id} className="flex flex-row items-center justify-center gap-4">
                            <h3>{part.name}</h3>
                            <button className="btn" onClick={() => removePartFromBuild(part)}>Remove</button>
                        </li>
                    ))}
                </ul>
            ) : (
                <p>No parts used in the build.</p>
            )}

            <h2>All Gun Parts</h2>
            <input
                type="text"
                placeholder="Search by name"
                value={searchQuery}
                className="input input-bordered w-full max-w-xs"
                onChange={(e) => setSearchQuery(e.target.value)}
            />
            {filteredParts.length > 0 ? (
                <ul>
                    {filteredParts.map((part) => (
                        <li key={part.id} className="flex flex-row items-center justify-center gap-4">
                            <h3>{part.name}</h3>
                            <p>{part.description}</p>
                            <button className="btn" onClick={() => addPartToBuild(part)}>Add</button>
                        </li>
                    ))}
                </ul>
            ) : (
                <p>No parts found.</p>
            )}

            <FileUpload/>
        </aside>
    );
}