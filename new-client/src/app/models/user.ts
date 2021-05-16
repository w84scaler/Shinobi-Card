export interface User {
    userName: string;
    token: string;
    nickname: string;
    banned: boolean;
    winCount: number;
    roles: string[];
}