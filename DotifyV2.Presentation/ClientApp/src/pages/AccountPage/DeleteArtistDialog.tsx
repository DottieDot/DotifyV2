import { Button, Dialog, DialogActions, DialogContent, DialogContentText, DialogTitle, TextField } from '@material-ui/core'
import React, { ChangeEvent, FormEvent, useCallback, useState } from 'react'
import { useDispatch } from 'react-redux'
import { useHistory } from 'react-router'
import * as endpoints from '../../api/endpoints'
import { showAlert } from '../../store/actions/Alerts'
import { setUserArtistId } from '../../store/actions/User'

interface Props {
  open: boolean
  onClose: () => void
}

export default ({ open, onClose }: Props) => {
  const [submitting, setSubmitting] = useState(false)
  const dispatch = useDispatch()

  const handleClose = useCallback(() => {
    if (!submitting) {
      onClose()
    }
  }, [submitting, onClose])

  const onDelete = useCallback(async () => {
    setSubmitting(true)
    const success = await endpoints.deleteArtist()
    if (success) {
      dispatch(showAlert('Artist deleted', 'success'))
      setSubmitting(false)
      dispatch(setUserArtistId(null))
      handleClose()
    }
    else {
      dispatch(showAlert('Failed to delete artist', 'error'))
      setSubmitting(false)
    }
  }, [setSubmitting, dispatch])

  return (
    <Dialog open={open} onClose={handleClose}>
      <DialogTitle>Delete Artist</DialogTitle>
      <DialogContent>
        <DialogContentText>
          Are you sure you want to delete your artist page?
        </DialogContentText>
      </DialogContent>
      <DialogActions>
        <Button
          disabled={submitting}
          onClick={handleClose}
          color="primary"
        >
          Cancel
        </Button>
        <Button
          disabled={submitting}
          onClick={onDelete}
          type="submit"
          color="primary"
        >
          Delete
        </Button>
      </DialogActions>
    </Dialog>
  )
}
