import { useCallback } from 'react'
import copyToClipboard from 'copy-to-clipboard'
import { useDispatch } from 'react-redux'
import { showAlert } from '../store/actions/Alerts'
import isMobile from 'is-mobile'

export default () => {
  const dispatch = useDispatch()

  return useCallback((title: string, url: string) => {
    if (navigator.share) {
      navigator.share({
        title, url
      }).then(() => {
        dispatch(showAlert('Artist shared', 'success'))
      }).catch(() => {
        if (!isMobile()) {
          if (copyToClipboard(window.location.href)) {
            dispatch(showAlert('Link copied to clipboard', 'success'))
          }
          else {
            dispatch(showAlert('Failed to copy to clipboard', 'error'))
          }
        }
        else {
          dispatch(showAlert('Failed to share', 'error'))
        }
      })
    }
    else {
      if (copyToClipboard(window.location.href)) {
        dispatch(showAlert('Link copied to clipboard', 'success'))
      }
      else {
        dispatch(showAlert('Failed to copy to clipboard', 'error'))
      }
    }
  }, [dispatch])
}
