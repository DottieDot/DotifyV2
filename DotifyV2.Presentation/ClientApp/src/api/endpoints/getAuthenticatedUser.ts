import apiRequest from '../apiRequest'
import { UserInfo, AuthenticatedUserResponse } from '../model'

export default async (): Promise<UserInfo | null> => {
  const response = await apiRequest(`/api/user`, 'GET')
  if (response.ok) {
    const data = await response.json() as AuthenticatedUserResponse
    return data
  }
  return null
}
