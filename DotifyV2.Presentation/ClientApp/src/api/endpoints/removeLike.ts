import apiRequest from '../apiRequest'
import { MediaTypes } from '../../common'

export default async (type: MediaTypes, id: number): Promise<boolean> => {
  const response = await apiRequest(`/api/${type}s/${id}/likes`, 'DELETE')
  if (response.ok) {
    const result = await response.json() as boolean
    return result
  }
  return false
}
