// import { useLoader } from "@react-three/fiber";
import { OBJLoader } from "three/examples/jsm/loaders/OBJLoader.js";
import { useEffect, useState } from "react";
import { API_URL } from "../constants.ts";
import { TransformControls } from "@react-three/drei";
import {Group, Object3DEventMap} from "three";

interface GunPart {
    id: string;
    name: string;
    description: string;
}

export function GunPartModel({ part }: { part: GunPart }) {
    const [obj, setObj] = useState<Group<Object3DEventMap>>();

    useEffect(() => {
        const loadModel = async () => {
            const loadedObj = await new OBJLoader().loadAsync(`${API_URL}/GunParts/download/${part.name}`);
            setObj(loadedObj);
        };

        loadModel();
    }, [part]);

    if (!obj) return null;

    return (
        <TransformControls>
            <primitive object={obj} />
        </TransformControls>
    );
}