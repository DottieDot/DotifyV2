import { useCallback } from 'react'
import copyToClipboard from 'copy-to-clipboard'
import { useDispatch } from 'react-redux'
import { showAlert } from '../store/actions/Alerts'

export default () => {
  const dispatch = useDispatch()

  return useCallback((title: string, url: string) => {
    if (navigator.share) {
      navigator.share({
        title, url
      })
    }
    else {
      copyToClipboard(window.location.href)
      dispatch(showAlert('Link copied to clipboard', 'success'))
    }
  }, [dispatch])
}
