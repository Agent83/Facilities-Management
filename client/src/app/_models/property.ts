import { Note } from "./note";
import { PremisesAddress } from "./premisesAddress";
import { PremisesTask } from "./premisesTask";
import { PropAccountant } from "./propAccountant";

export interface Property {   
        id: string;
        premiseNumber: string;
        premiseName: string;
        isDeleted: boolean;
        dateCreated: Date;
        phoneNumber1: string;
        phoneNumber2: string;
        email: string;
        premisesAddressId: number;
        propAccountant: PropAccountant;
        premisesAddress: PremisesAddress;
        notes: Note[];
        premisesTasks: PremisesTask[];
}

