import apiRequest from '../apiRequest'
import { SignUpResponse, SignUpRequest } from '../model'

export default async (username: string, password: string) => {
  const response = await apiRequest('/api/users', 'POST', {
    username, password
  } as SignUpRequest)
  if (response.ok) {
    const data = await response.json() as SignUpResponse
    return data.api_token
  }
  return null
}
