export interface AuthResponseDto {
    email: string;
    isAuthSuccessful: boolean;
    errorMessage: string;
    token: string;
}