import { Note } from "./note";
import { PremisesTask } from "./premisesTask";

export interface Contractor {
    id: string;
    businessName: string;
    firstName: string;
    lastName: string;
    rating: number;
    contractorTypeId: number;
    greenLightEnum: string;
    phoneNumber1: string;
    phoneNumber2: string;
    email: string;
    isDeleted: boolean;
    dateCreated: Date;
    notes: Note[];
    jobs: PremisesTask[];
}