import apiRequest from '../apiRequest'
import { ChangeUsernameRequest } from '../model'

export default async (username: string, password: string): Promise<boolean> => {
  const response = await apiRequest(`/api/user/username`, 'PATCH', {
    username,
    password,
  } as ChangeUsernameRequest)
  if (response.ok) {
    const result = await response.json() as boolean
    return !!result
  }
  return false
}
