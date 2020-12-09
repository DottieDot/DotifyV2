import apiRequest from '../apiRequest'
import { LoginResponse, LoginRequest } from '../model'

export default async (username: string, password: string) => {
  const response = await apiRequest('/api/authenticate', 'POST', {
    username, password
  } as LoginRequest)
  if (response.ok) {
    const data = await response.json() as LoginResponse
    return data.api_token
  }
  return null
}
