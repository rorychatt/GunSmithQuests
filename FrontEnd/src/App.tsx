import './App.css'
import {Canvas, useFrame} from "@react-three/fiber";
import {MutableRefObject, useRef, useState} from "react";
import {Mesh} from "three";
import FileUpload from "./components/FileUpload.tsx";

function App() {

    return (
        <>
            <h1 className="text-3xl font-bold underline">
                Hello world!
            </h1>
            <button className="btn">
                Click me
            </button>

            <Canvas>
                <ambientLight intensity={Math.PI / 2}/>
                <spotLight position={[10, 10, 10]} angle={0.15} penumbra={1} decay={0} intensity={Math.PI}/>
                <pointLight position={[-10, -10, -10]} decay={0} intensity={Math.PI}/>
                <Box position={[-1.2, 0, 0]}/>
                <Box position={[1.2, 0, 0]}/>
            </Canvas>
            
            <FileUpload/>
        </>
    )
}

function Box({position}: { position: number[]}) {
    const meshRef: MutableRefObject<Mesh | null> = useRef(null)
    const [hovered, setHover] = useState(false)
    const [active, setActive] = useState(false)

    useFrame((_, delta) => {
        if (meshRef.current) {
            meshRef.current.rotation.x += delta;
        }
    })
    
    return (
        <mesh
            {...position}
            ref={meshRef}
            scale={active ? 1.5 : 1}
            onClick={() => setActive(!active)}
            onPointerOver={() => setHover(true)}
            onPointerOut={() => setHover(false)}>
            <boxGeometry args={[1, 1, 1]} />
            <meshStandardMaterial color={hovered ? 'hotpink' : 'orange'} />
        </mesh>
    )
}

export default App
