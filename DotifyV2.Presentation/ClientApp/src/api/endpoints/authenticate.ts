import apiRequest from '../apiRequest'
import { AuthenticationResponse } from '../model'

export default async (username: string, password: string) => {
  const response = await apiRequest('/api/authenticate', 'POST', {
    username, password
  })
  console.log(username, password)
  if (response.ok) {
    const data = await response.json() as AuthenticationResponse
    return data.api_token
  }
  return null
}
