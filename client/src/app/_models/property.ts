import { Note } from "./note";
import { PremisesAddress } from "./premisesAddress";
import { PremisesTask } from "./premisesTask";

export interface Property {   
        id: number;
        premiseName: string;
        isDeleted: boolean;
        dateCreated: Date;
        phoneNumber1: string;
        phoneNumber2: string;
        email: string;
        premisesAddressId: number;
        premisesAddress: PremisesAddress;
        notes: Note[];
        premisesTasks: PremisesTask[];
}

