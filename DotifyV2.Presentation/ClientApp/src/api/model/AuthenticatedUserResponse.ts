
export default interface AuthenticatedUserResponse {
  id: number
  username: string
  likes: {
    songs: number[]
    albums: number[]
    artists: number[]
  }
}
