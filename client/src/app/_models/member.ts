import { Photo } from "./photo";

export interface Member {
    id: number;
    userName: string;
    photoUrl: string;
    age: number;
    created: Date;
    knownAs: string;
    lastActive: Date;
    isDeleted: boolean;
    photos: Photo[];
}