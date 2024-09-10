import {Canvas} from "@react-three/fiber";
import {Suspense} from "react";
import {OrbitControls} from "@react-three/drei";

export function Main() {
    return (
        <main className="flex flex-col items-center justify-center text-center">
            <Canvas className="border-2 border-gray-300 rounded-lg p-2">
                <Suspense fallback={null}>
                    <ambientLight />
                    <pointLight position={[10, 10, 10]} />
                    <mesh>
                        <boxGeometry args={[1, 1, 1]} />
                        <meshStandardMaterial color="orange" />
                    </mesh>
                    <OrbitControls />
                </Suspense>
            </Canvas>
        </main>
    );
}