import {Canvas, useFrame} from "@react-three/fiber";
import { Suspense, useState } from "react";
import { OrbitControls } from "@react-three/drei";
import {GunPart} from "./types.ts";
import {GunPartModel} from "./GunPartModel.tsx";
import {Aside} from "./Aside.tsx";
import {MOUSE} from "three";

export function Main() {
    const [isFullscreen, setIsFullscreen] = useState(false);
    const [resetCameraFlag, setResetCameraFlag] = useState(false);
    const [usedParts, setUsedParts] = useState<GunPart[]>([]);

    const handleAddPart = (part: GunPart) => {
        setUsedParts([...usedParts, part]);
    };

    const toggleFullscreen = () => {
        setIsFullscreen(!isFullscreen);
    };

    const resetCamera = () => {
        setResetCameraFlag(true);
    };

    return (
        <main className={`flex flex-col items-center justify-center text-center ${isFullscreen ? 'fixed top-0 left-0 w-full h-full' : ''}`}>
            <div className="mb-4">
                <button onClick={toggleFullscreen} className="mr-2 p-2 bg-blue-500 text-white rounded">Toggle Fullscreen</button>
                <button onClick={resetCamera} className="p-2 bg-green-500 text-white rounded">Reset Camera</button>
            </div>
            <Canvas className="border-2 border-gray-300 rounded-lg p-2" gl={{ alpha: true }} style={{ background: '#e0f7fa' }} camera={{ position: [0, 0, 5] }}>
                <Suspense fallback={null}>
                    <ambientLight intensity={0.5} />
                    <pointLight position={[10, 10, 10]} />
                    <directionalLight position={[5, 5, 5]} intensity={1} />
                    <spotLight position={[-5, 5, 5]} angle={0.3} penumbra={1} intensity={1} castShadow />
                    {usedParts.map(part => (
                        <GunPartModel key={part.id} part={part} />
                    ))}
                    <OrbitControls
                        mouseButtons={{
                            LEFT: undefined,
                            RIGHT: MOUSE.PAN                            
                        }}
                    />
                    <ResetCamera resetCameraFlag={resetCameraFlag} setResetCameraFlag={setResetCameraFlag} />
                </Suspense>
            </Canvas>

            <Aside onAddPart={handleAddPart}/>
        </main>
    );
}

function ResetCamera({ resetCameraFlag, setResetCameraFlag }: { resetCameraFlag: boolean, setResetCameraFlag: (flag: boolean) => void }) {
    useFrame(({ camera }) => {
        if (resetCameraFlag) {
            camera.position.set(0, 0, 5);
            camera.lookAt(0, 0, 0);
            setResetCameraFlag(false);
        }
    });
    return null;
}