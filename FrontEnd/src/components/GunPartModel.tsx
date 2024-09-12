import { OBJLoader } from "three/examples/jsm/loaders/OBJLoader.js";
import { useEffect, useState } from "react";
import { API_URL } from "../constants.ts";
import { TransformControls } from "@react-three/drei";
import { Group, Object3DEventMap } from "three";

interface GunPart {
    id: string;
    name: string;
    description: string;
}

export function GunPartModel({ part }: { part: GunPart }) {
    const [obj, setObj] = useState<Group<Object3DEventMap>>();
    const [mode, setMode] = useState<"translate" | "rotate">("translate");

    useEffect(() => {
        const loadModel = async () => {
            const loadedObj = await new OBJLoader().loadAsync(`${API_URL}/GunParts/download/${part.name}`);
            setObj(loadedObj);
        };

        loadModel();
    }, [part]);

    useEffect(() => {
        const handleKeyDown = (event: KeyboardEvent) => {
            if (event.key === "r" || event.key === "R") {
                setMode("rotate");
            }
        };

        const handleKeyUp = (event: KeyboardEvent) => {
            if (event.key === "r" || event.key === "R") {
                setMode("translate");
            }
        };

        window.addEventListener("keydown", handleKeyDown);
        window.addEventListener("keyup", handleKeyUp);

        return () => {
            window.removeEventListener("keydown", handleKeyDown);
            window.removeEventListener("keyup", handleKeyUp);
        };
    }, []);

    if (!obj) return null;

    return (
        <TransformControls mode={mode}>
            <primitive object={obj} />
        </TransformControls>
    );
}