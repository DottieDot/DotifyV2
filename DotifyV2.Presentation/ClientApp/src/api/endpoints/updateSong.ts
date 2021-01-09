import apiRequest from '../apiRequest'

export default async (songId: number, name: string, duration: number): Promise<boolean> => {
  const response = await apiRequest(`/api/songs/${songId}`, 'PATCH', {
      name,
      duration,
  })
  if (response.ok) {
    const result = await response.json() as boolean
    return !!result
  }
  return false
}
