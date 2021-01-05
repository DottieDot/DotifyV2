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
  const [name, setName] = useState('')
  const [submitting, setSubmitting] = useState(false)
  const dispatch = useDispatch()
  const history = useHistory()

  const handleClose = useCallback(() => {
    if (!submitting) {
      onClose()
      setName('')
    }
  }, [submitting, onClose, setName])

  const onNameChange = useCallback((event: ChangeEvent<HTMLInputElement>) => {
    setName(event.target.value)
  }, [setName])

  const onSubmit = useCallback(async (event: FormEvent<HTMLFormElement>) => {
    event.preventDefault()
    setSubmitting(true)
    const artist = await endpoints.createArtist(name)
    if (artist) {
      dispatch(setUserArtistId(artist.id))
      history.push('/artist')
    }
    else {
      dispatch(showAlert('Failed to create artist', 'error'))
      setSubmitting(false)
    }
  }, [setSubmitting, name, history, dispatch])

  return (
    <Dialog open={open} onClose={handleClose}>
      <form onSubmit={onSubmit}>
        <DialogTitle>Create Artist</DialogTitle>
        <DialogContent>
          <DialogContentText>
            Enter a name for your artist page.
          </DialogContentText>
          <TextField
            margin="dense"
            label="Name"
            type="text"
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
            Create
          </Button>
        </DialogActions>
      </form>
    </Dialog>
  )
}
