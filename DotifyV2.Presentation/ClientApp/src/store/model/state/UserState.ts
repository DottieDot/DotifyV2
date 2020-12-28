import { UserInfo } from '../../../api/model'

type UserState = Omit<UserInfo, 'likes'> | null

export default UserState
