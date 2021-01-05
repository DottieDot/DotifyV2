import apiRequest from '../apiRequest'
import { ChangePasswordRequest } from '../model'

export default async (currentPassword: string, newPassword: string): Promise<boolean> => {
  const response = await apiRequest(`/api/user/password`, 'PATCH', {
    current_password: currentPassword,
    new_password: newPassword,
  } as ChangePasswordRequest)
  if (response.ok) {
    const result = await response.json() as boolean
    return !!result
  }
  return false
}
