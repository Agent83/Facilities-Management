import { Guid } from "guid-typescript";
import { Contractor } from "./contractor";
import { Note } from "./note";
import { PremisesAddress } from "./premisesAddress";
import { PremisesTask } from "./premisesTask";
import { PropAccountant } from "./propAccountant";

export interface Property {   
        id: string;
        premiseNumber?: any;
        premiseName: string;
        isActive: boolean;
        isDeleted: boolean;
        dateCreated: Date;
        phoneNumber1: string;
        phoneNumber2: string;
        email: string;
        accountantId: string;
        accountant: PropAccountant;
        premisesAddress: PremisesAddress;
        notes: Note[];
        premisesTasks: PremisesTask[];
        contractors: Contractor[];
}

