import { useEffect, useState } from "react";
import { API_URL } from "../constants.ts";
import { Canvas, useLoader } from "@react-three/fiber";
import { OBJLoader } from "three/examples/jsm/loaders/OBJLoader.js";
import { OrbitControls } from "@react-three/drei";

interface GunPart {
    guid: string;
    name: string;
    description: string;
}

export function Aside() {
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
    };

    const removePartFromBuild = (part: GunPart) => {
        setUsedParts(usedParts.filter(p => p.guid !== part.guid));
    };

    const filteredParts = gunParts.filter(part =>
        part.name.toLowerCase().includes(searchQuery.toLowerCase())
    );

    return (
        <aside className="flex flex-col items-center justify-center text-center border-2 border-gray-300 rounded-lg p-2">
            <h2>Used Gun Parts</h2>
            {usedParts.length > 0 ? (
                <ul>
                    {usedParts.map((part) => (
                        <li key={part.guid} className="flex flex-row items-center justify-center gap-4">
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
                        <li key={part.guid} className="flex flex-row items-center justify-center gap-4">
                            <h3>{part.name}</h3>
                            <p>{part.description}</p>
                            <button className="btn" onClick={() => addPartToBuild(part)}>Add</button>
                        </li>
                    ))}
                </ul>
            ) : (
                <p>No parts found.</p>
            )}
        </aside>
    );
}

function GunPartModel({ part }: { part: GunPart }) {
    const obj = useLoader(OBJLoader, `${API_URL}/GunParts/${part.guid}/model.obj`);
    return <primitive object={obj} />;
}

export function Main() {
    const [usedParts] = useState<GunPart[]>([]);

    return (
        <main className="flex flex-col items-center justify-center text-center">
            <Canvas className="border-2 border-gray-300 rounded-lg p-2" gl={{ alpha: true }} style={{ background: '#e0f7fa' }} camera={{ position: [0, 0, 5] }}>
                <ambientLight intensity={0.5} />
                <pointLight position={[10, 10, 10]} />
                <directionalLight position={[5, 5, 5]} intensity={1} />
                <spotLight position={[-5, 5, 5]} angle={0.3} penumbra={1} intensity={1} castShadow />
                {usedParts.map(part => (
                    <GunPartModel key={part.guid} part={part} />
                ))}
                <OrbitControls />
            </Canvas>
        </main>
    );
}