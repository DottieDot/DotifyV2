import { Button, Dialog, DialogActions, DialogContent, DialogContentText, DialogTitle, TextField } from '@material-ui/core'
import React, { ChangeEvent, FormEvent, useCallback, useState } from 'react'
import { useDispatch } from 'react-redux'
import { useHistory } from 'react-router'
import * as endpoints from '../../api/endpoints'
import { showAlert } from '../../store/actions/Alerts'

interface Props {
  open: boolean
  onClose: (name: string | null) => void
  currentName: string
  albumId: number
}

export default ({ open, onClose, currentName, albumId }: Props) => {
  const [name, setName] = useState('')
  const [submitting, setSubmitting] = useState(false)
  const dispatch = useDispatch()
  const history = useHistory()

  const handleClose = useCallback(() => {
    if (!submitting) {
      onClose(null)
      setName('')
    }
  }, [submitting, onClose, setName])

  const onNameChange = useCallback((event: ChangeEvent<HTMLInputElement>) => {
    setName(event.target.value)
  }, [setName])

  const onSubmit = useCallback(async (event: FormEvent<HTMLFormElement>) => {
    event.preventDefault()
    setSubmitting(true)
    const success = await endpoints.changeAlbumName(albumId, name)
    if (success) {
      dispatch(showAlert('Renamed album', 'success'))
      setSubmitting(false)
      setName('')
      onClose(name)
    }
    else {
      dispatch(showAlert('Failed to rename album', 'error'))
      setSubmitting(false)
    }
  }, [setSubmitting, name, history, dispatch])

  return (
    <Dialog open={open} onClose={handleClose}>
      <form onSubmit={onSubmit}>
        <DialogTitle>Rename Album</DialogTitle>
        <DialogContent>
          <DialogContentText>
            Enter a new name for the album.
          </DialogContentText>
          <TextField
            margin="dense"
            label="Name"
            type="text"
            placeholder={currentName}
            value={name}
            onChange={onNameChange}
            disabled={submitting}
            required
            fullWidth
          />
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
            disabled={!name.trim() || submitting}
            type="submit"
            color="primary"
          >
            Save
          </Button>
        </DialogActions>
      </form>
    </Dialog>
  )
}
