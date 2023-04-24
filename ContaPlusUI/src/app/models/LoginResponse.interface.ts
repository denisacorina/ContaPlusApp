export interface LoginResponse {
    accessToken: string;
    refreshToken: string;
    createdAt: Date;
    expiresAt: Date;
    isAuthSuccessful: boolean;
  }